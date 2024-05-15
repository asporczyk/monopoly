<script setup lang="ts">
import Player from '@/views/Game/Player.vue'
import { useGameStore } from '@/stores/game'
import { storeToRefs } from 'pinia'

const gameStore = useGameStore()

const { players } = storeToRefs(gameStore)
</script>
<template>
  <div class="d-flex flex-row w-100 fill-height justify-center">
    <div class="d-flex flex-column justify-space-around align-center w-100">
      <Player :player="players[0]" />
      <Player :player="players[1]" />
    </div>
    <slot />
    <div class="d-flex flex-column justify-space-around align-center w-100">
      <Player :player="players[2]" />
      <Player :player="players[3]" />
    </div>
  </div>
</template>
