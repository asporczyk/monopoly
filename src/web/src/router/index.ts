import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'start',
      component: () => import('@/views/Start.vue'),
    },
    {
      path: '/game',
      name: 'game',
      component: () => import('@/views/Game.vue'),
    },
  ],
})

export default router
