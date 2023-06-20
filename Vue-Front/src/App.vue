<template>
  <div class="app" id="app">
    <Delivery></Delivery>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import Delivery from "./View/Delivery.vue";

@Component({
  components: {
    Delivery,
  },
})
export default class App extends Vue {}
</script>

<style lang="scss">
</style>
