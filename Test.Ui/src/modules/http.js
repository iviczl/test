let attempt = 5;

async function postJson(url = '', data = {}, headers = {}) {
  return doFetch(url, data, 'POST', headers);
}

async function putJson(url = '', data = {}, headers = {}) {
  return doFetch(url, data, 'PUT', headers);
}

async function deleteJson(url = '', data = {}, headers = {}) {
  return doFetch(url, data, 'DELETE', headers);
}

async function getJson(url = '', headers = {}) {
  return doFetch(url, null, 'GET', headers);
}

async function getBlob(url = '', data = null, headers = {}) {
  if(data) {
    return doFetch(url, data, 'POST', headers, 'blob');  
  }
  return doFetch(url, null, 'GET', headers, 'blob');
}

async function doFetch(url = '', data = {}, verb = 'GET', headers = {}, responseType = 'json') {
  url = !url.startsWith('http') ? 'http://' + url : url;
  const response = await fetch(url, {
    method: verb,
    mode: 'cors', // no-cors, cors, *same-origin
    cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
    credentials: 'same-origin', // include, *same-origin, omit
    headers: {
      'Content-Type': 'application/json; charset=utf-8',
      ...headers
    },
    redirect: 'follow', // manual, *follow, error
    referrer: 'no-referrer', // no-referrer, *client
    body: verb == 'GET' ? null : JSON.stringify(data) // body data type must match "Content-Type" header
  });
  if(response.status < 200 || response.status > 299) {
    console.warn(await response.text());
    return null;
  }
  try {
    const resultData = responseType ? (responseType === 'blob' ? response.blob() : response.json()) : response.json();
    const dispositionHeader = response.headers.values('Content-Disposition');
    const disposition = dispositionHeader? dispositionHeader.next().value : '';
    const result = responseType ? 
      (responseType === 'blob' ? { disposition: disposition, data: resultData } : resultData) : 
      resultData;
    attempt = 5;
    return result;
  } catch (error) {
    debugger;
    if (attempt == 0) {
      throw new TypeError('error: ' + error);
    }
    attempt--;
    return doFetch(url, data, verb, headers, responseType);
  }
}

export {
  postJson,
  putJson,
  getJson,
  deleteJson,
  getBlob
};
