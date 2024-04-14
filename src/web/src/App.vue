<script setup lang="ts">
import { RouterView } from 'vue-router'
import AppHeader from '@/components/organisms/AppHeader/AppHeader.vue'
</script>

<template>
  <v-app>
    <AppHeader />
    <v-main class="d-flex align-center justify-center">
      <RouterView />
    </v-main>
  </v-app>
</template>
