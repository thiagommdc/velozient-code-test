import Vue from 'vue'
import App from './App.vue'
import router from './router'

Vue.config.productionTip = false

Vue.filter('stripHtml', function (html: string) {
  const tmp = document.createElement('DIV')
  tmp.innerHTML = html
  return tmp.textContent || tmp.innerText || ''
})

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
