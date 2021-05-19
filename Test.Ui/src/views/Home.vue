<template>
    <div>
        <pager :totalCount="pagination.totalItemCount" :pageSize="pagination.pageSize" :page="pagination.page" @page-previous="getDataPage" @page-next="getDataPage"/>
        <grid-table v-if="measurementData.length > 0" key="measurements" ref="data" :columns="tableCols()" :rows="tableRows()" :selectable="true" 
            @selected-row-changed="selectRow($event)" :tableHeight="340"  :fontSize="0.8" />
    </div>
</template>

<script>
import { measurementService } from '@/modules/services.js';
import pager from '@/components/pager.vue';
import gridTable from '@/components/gridTable.vue';
import { backByDays } from '@/modules/dateHelper.js';
export default {
    name: 'home',
    components: {
        'grid-table': gridTable,
        pager
    },
    data() {
        return {
            startDate: backByDays(10000, this.endDate),
            endDate: new Date(),
            jsn: null,
            shopId: null,
            measurementPointId: null,
            pagination: { totalItemCount: 0, pageSize: 50, page: 1, orderBy: 'id' },
            measurementData: []
        };
    },
    methods: {
        selectRow(row) {


        },
        async getDataPage(requestedPage) {
			if(requestedPage < 1 || requestedPage > Math.ceil(this.pagination.totalCount / this.pagination.pageSize) || this.pagination.page == requestedPage) {
				return;
			}
			this.pagination.page = requestedPage;
			await this.refresh();
		},
        tableCols() { 
            let cols = [
                { name: 'id', title: 'Mérés azonosítója', type: 'number', width: 4, fontSize: 0.9 },
                { name: 'jsn', title: 'JSN', type: 'string', width: 11, fontSize: 0.9 },
                { name: 'vehicleModel', title: 'jármű modell', type: 'string', width: 11, fontSize: 0.9 },
                { name: 'shopName', title: 'Állomás', type: 'string', width: 11, fontSize: 0.9 },
                { name: 'measurementPointName', title: 'Mérési pont', type: 'string', width: 11, fontSize: 0.9 },
                { name: 'date', title: 'Mérés ideje', type: 'date', width: 11, fontSize: 0.9 },
                { name: 'gap', title: 'Gap', type: 'number', width: 11, fontSize: 0.9 },
                { name: 'flush', title: 'Flush', type: 'number', width: 11, fontSize: 0.9 },
            ];
            return cols;
        },
        tableRows() {
			if(!this.measurementData) { return []; }
			return this.measurementData.map(d => {
				let row =	[];
				for(let data in d) {
					row.push({ name: data, value: d[data] == null ? null : d[data] });
				}
				return row;
			});
        },
        async refresh() {
			let dataPromise = measurementService.getMeasurements(this.startDate, this.endDate, this.jsn, this.shopId, this.measurementPointId, this.pagination.page, 
                this.pagination.pageSize, this.pagination.orderBy);
			await Promise.all([dataPromise]);
			dataPromise.then(r => {
				this.measurementData = r.data.sort((a, b) => a.date.localeCompare(b.date)); 
                this.pagination = r.pagination;
			});
        }

    },
    mounted() {
        this.refresh();
    }
}
</script>