<template>
<nav v-if="isVisible()" class="pagination is-small is-centered" role="navigation" aria-label="pagination">
  <a class="pagination-previous" :disabled="!hasPrevious()" @click="previous">előző</a>
  <a class="pagination-next" :disabled="!hasNext()" @click="next">következő</a>
  <ul class="pagination-list">
		<li><a class="pagination-link">{{ page }}</a></li>
	</ul>
  <!-- <ul class="pagination-list">
    <li><a class="pagination-link" aria-label="Goto page 1">1</a></li>
    <li><span class="pagination-ellipsis">&hellip;</span></li>
    <li><a class="pagination-link" aria-label="Goto page 45">45</a></li>
    <li><a class="pagination-link is-current" aria-label="Page 46" aria-current="page">46</a></li>
    <li><a class="pagination-link" aria-label="Goto page 47">47</a></li>
    <li><span class="pagination-ellipsis">&hellip;</span></li>
    <li><a class="pagination-link" aria-label="Goto page 86">86</a></li>
  </ul> -->
</nav>
</template>
<script>
export default {
		name: 'pager',
		props: {
			totalCount: { type: Number, required: true },
			pageSize: { type: Number, required: true },
			page: { type: Number, required: true }
		},
		data() {
			return {

			};
		},
		methods: {
			isVisible() {
				return this.pageCount() > 1;
			},
			pageCount() {
				return Math.ceil(this.totalCount / this.pageSize);
			},
			hasNext() {
				return this.page < this.pageCount();
			},
			hasPrevious() {
				return this.page > 1;
			},
			previous() {
				if(this.hasPrevious()) {
					this.$emit('page-previous', this.page - 1);
				}
			},
			next() {
				if(this.hasNext()) {
					this.$emit('page-next', this.page + 1);
				}
			}
		}
}
</script>
<style scoped>

</style>