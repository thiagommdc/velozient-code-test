<script lang="ts">
import { IOptimizedRoutes } from '@/interfaces/IOptimizedRoutes';
import { IDrone } from '@/interfaces/IDrone';
import { Component, Vue } from "vue-property-decorator";
import { IDelivery } from '@/interfaces/IDelivery';
import { deleteDeliveryService, deleteDroneService, getDeliveriesService, getDronesService, getOptimizedRoutesService, includeDeliveryService, includeDroneService, updateDeliveryService, updateDroneService } from '@/service/servicos.service';

@Component({
  components: {},
})
export default class Delivery extends Vue {
  
  optimizedRoutes: IOptimizedRoutes[] = []
  drones: IDrone[] = []  
  deliveries: IDelivery[] = []

  newDrone: IDrone = {
      id:0,
      name: '',
      maxWeight: 0
    }

  newDelivery: IDelivery = {
      id:0,
    location: '',
    weight: 0
  }

  beforeMount() {
    this.updateRoutes() 
    this.refreshDrones() 
    this.updateDeliveries()
  }

  async updateRoutes() {
    this.optimizedRoutes = await getOptimizedRoutesService()
  }
  
  async refreshDrones() {
    this.drones = await getDronesService()
  }
  
  async updateDeliveries() {
    this.deliveries = await getDeliveriesService()
  }

  async includeDrone() {
    await includeDroneService(this.newDrone)
    this.refreshDrones()
    this.updateRoutes() 
    this.newDrone = {
      id:0,
      name: '',
      maxWeight: 0
    }
  }
  
  async deleteDrone(drone: IDrone) {
    await deleteDroneService(drone)
    this.refreshDrones()
    this.updateRoutes() 
  }

  async updateDrones(drone: IDrone) {
    await updateDroneService(drone)
    this.updateRoutes()
  }

  async IncludeDelivery() {
    await includeDeliveryService(this.newDelivery)
    this.updateDeliveries()
    this.updateRoutes() 
    this.newDelivery = {
      id:0,
      location: '',
      weight: 0
    }
  }

  async deleteDelivery(delivery: IDelivery) {
    await deleteDeliveryService(delivery)
    this.updateDeliveries()
    this.updateRoutes()
  }

  async UpdateDelivery(delivery: IDelivery) {
    await updateDeliveryService(delivery)
    this.updateDeliveries()
    this.updateRoutes()
  }
}
</script>
<template>
  <div class="content">
    <div class="header">
      <button>Drones | Deliveries</button>
      <button>Best Route</button>
    </div>
    <div class="info">
      <div class="base drones">
        <h4>Drones</h4>
        <hr/>
        <div class="add-list">
          <input type="text" placeholder="Drone name" v-model="newDrone.name"/>
          <input type="number" placeholder="Max weight" v-model="newDrone.maxWeight"/>
          <button @click="includeDrone()">Include Drone</button>
        </div>
        <div class="add-list" v-for="(drone, index) in drones" :key="'dr' + drone.id">
          <input type="text" placeholder="Drone name" v-model="drones[index].name"/>
          <input type="number" placeholder="Max weight" v-model="drones[index].maxWeight"/>
          <button @click="UpdateDrones(drones[index])">Edit Drone</button>
          <button @click="deleteDrone(drones[index])">Delete Drone</button>
        </div>
        <h4>Deliveries</h4>
        <hr/>
        <div class="add-list">
          <input type="text" placeholder="Location name" v-model="newDelivery.location"/>
          <input type="number" placeholder="Max weight" v-model="newDelivery.weight"/>
          <button @click="IncludeDelivery()">Include Delivery</button>
        </div>
        <div class="add-list" v-for="(delivery, index) in deliveries" :key="'dl' + delivery.id">
          <input type="text" placeholder="Location name" v-model="deliveries[index].location"/>
          <input type="number" placeholder="Max weight" v-model="deliveries[index].weight"/>
          <button @click="UpdateDelivery(deliveries[index])">Edit Delivery</button>
          <button @click="deleteDelivery(deliveries[index])">Delete Delivery</button>
        </div>
      </div>
      <div class="base">
        <div v-for="route in optimizedRoutes" :key="'r' + route.droneName">
          <h4>{{route.droneName}}</h4>
           <p v-for="(trip, index) in route.tripsList" :key="route.droneName + index">
            Trip #{{index + 1}}
            {{trip}}
            </p>
        </div>
      </div>
    </div>
  </div>
</template>
<style lang="scss">
input {
  width: 100%;
  padding: 5px 20px;
  border: 1px solid rgba(0,0,0,0.1);
  margin: 0 5px;
      }
.content {
  position: relative;
  width: 100%;
  
  & .header {
    display: flex;
    justify-content: space-between;
    flex-direction: row;
    padding: 20px;

    & button {
      width: 49%;
      background-color: white;
      padding: 20px;   
      border: none;   
      cursor: pointer;
      box-shadow: 3px 3px 5px rgba(0,0,0,0.05);
    }   
  }

   & .info {
      position: relative;
      width: 100%;     
      display: flex;
      flex-direction: row;

      & .base {
        background-color: white;
        box-shadow: 3px 3px 5px rgba(0,0,0,0.05);
        position: relative;
        padding: 20px;
        width: 100%;

        & h4 { margin-top: 30px;}
      }

      & .drones {

        & .add-list
        {
          position: relative;
          width: 100%;     
          display: flex;
          flex-direction: row;
          flex-grow: 1;
          margin: 5px;

          & button {
            text-overflow: ellipsis;
            white-space: nowrap;
            display: block;
            margin: 10px;
          }
        }
      }
    }
}

</style>
