import listGetter from '@/modules/listGetter.js';
import { updateEntity } from '@/modules/dataPutter.js';
import { getData, getEntity } from '@/modules/dataGetter';

let measurementService = {
  async getMeasurements(startDate, endDate, jsn, shopId, measurementPointId, page, pageSize, orderBy) {
    return listGetter.getGeneralList('measurement/list', { startDate, endDate, jsn, shopId, measurementPointId }, true, page, pageSize, orderBy);
  },
  async getMeasurement(measurementId) {
    return getEntity(`measurement?id=${measurementId}`);
  },
  async updateMeasurement(id, vehicleId, shopId, measurementPointId, date, gap, flush) {
    return updateEntity('measurement/update', { id, vehicleId, shopId, measurementPointId, date, gap, flush });
  },
  // async getDataByChannels(stationIds, channels, start, end) {
  //   return getData('measurements/channeldata', { stationIds: stationIds, start: epochFromDate(start), end: epochFromDate(end), channels: channels });
  // }
}

let measurementPointService = {
  async getMeasurementPoints() {
    return getData('measurementpoint/list', {});
  }
}

let shopService = {
  async getShops() {
    return getData('shop/list', {});
  }
}

export {
    measurementService,
    measurementPointService,
    shopService
}
