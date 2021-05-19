<template>
  <div id="app">
    <p>
      <router-link to="/">Kezdőlap</router-link>
      <router-link to="/about">About</router-link>
    </p>
    <router-view />
  </div>
</template>

<script>

export default {
  name: 'App',
  components: {
  }
}
</script>

<style>
</style>
