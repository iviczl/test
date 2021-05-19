<template>
    <grid-table v-if="measurementData.length > 0" key="measurements" ref="data" :columns="tableCols()" :rows="tableRows()" 
					:tableHeight="340"  :fontSize="0.8" />
</template>

<script>
import { measurementService } from '@/modules/services.js';
import gridTable from '@/components/gridTable.vue';
import { backByDays } from '@/modules/dateHelper.js';
export default {
    name: 'home',
    components: {
        'grid-table': gridTable
    },
    data() {
        return {
            startDate: backByDays(10, this.endDate),
            endDate: new Date(),
            jsn: null,
            shopId: null,
            measurementPointId: null,
            pageNumber: 1,
            measurementData: []
        };
    },
    methods: {
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
			let dataPromise = measurementService.getMeasurements(this.startDate, this.endDate, this.jsn, this.shopId, this.measurementPointId, this.pageNumber);
			await Promise.all([dataPromise]);
			dataPromise.then(r => {
				this.measurementData = r.sort((a, b) => a.date.localeCompare(b.date)); 
			});
        }

    },
    mounted() {
        this.refresh();
    }
}
</script>