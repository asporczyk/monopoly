import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'menu',
      component: () => import('@/views/MainMenu.vue'),
    },
    {
      path: '/game',
      name: 'game',
      component: () => import('@/views/Game/Game.vue'),
    },
    {
      path: '/lobby',
      name: 'lobby',
      component: () => import('@/views/Game/GameLobby.vue'),
    },
  ],
})

export default router
