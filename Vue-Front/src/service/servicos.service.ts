import { IDrone } from './../interfaces/IDrone';
import { IOptimizedRoutes } from '@/interfaces/IOptimizedRoutes'
import { api } from './http.service'
import { IDelivery } from '@/interfaces/IDelivery';

export async function getOptimizedRoutesService() {
  const { data, status } = await api.get<IOptimizedRoutes[]>('/Routes')
  return data
}

export async function getDronesService() {
  const { data } = await api.get<IDrone[]>('/Drones')
  return data
}

export async function updateDroneService(drone: IDrone) {
  const { data, status } = await api.put('/Drones', [drone])
  if (status == 200) return data
  else alert('error: Drone was not updated')
}

export async function deleteDroneService(drone: IDrone) {
  const { data, status } = await api.delete('/Drones', { data: drone })
  if (status == 200) return data
  else alert('error: Drone was not deleted')
}

export async function includeDroneService(drone: IDrone) {
  const { data, status } = await api.post('/Drones', [drone])
  if (status == 200) return data
  else alert('error: Could´t include this drone')
}

export async function getDeliveriesService() {
  const { data } = await api.get<IDelivery[]>('/deliveries')
  return data
}

export async function updateDeliveryService(delivery: IDelivery) {
  const { data, status } = await api.put('/Deliveries', [delivery])
  if (status == 200) return data
  else alert('error: Delivery was not updated')
}

export async function includeDeliveryService(delivery: IDelivery) {
  const { data, status } = await api.post('/Deliveries', [delivery])
  if (status == 200) return data
  else alert('error: Could´t include this delivery')
}

export async function deleteDeliveryService(delivery: IDelivery) {
  const { data, status } = await api.delete('/Deliveries', { data: delivery })
  if (status == 200) return data
  else alert('error: Delivery was not deleted')
}

