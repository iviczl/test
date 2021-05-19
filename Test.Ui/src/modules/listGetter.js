import {getList, getListPage} from './dataGetter.js';

let pageSize = 50;

async function getGeneralList(url, query = null, getAnyway = false, page = null, itemCount = pageSize) {
  if(page) {
    return getListPage(url, query, itemCount, page);
  }
  return getList(url, query, itemCount, getAnyway);
}


export default {
  getGeneralList
}
