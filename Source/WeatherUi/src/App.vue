<template>
  <Weather />
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import Weather from "./components/Weather.vue";

@Options({
  components: {
    Weather
  }
})
export default class App extends Vue {}
</script>

<style lang="scss"></style>
