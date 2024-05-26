<script setup lang="ts">
import Player from '@/views/Game/Players/Player.vue'
import { useGameStore } from '@/stores/game'
import { storeToRefs } from 'pinia'

interface PlayersWrapperProps {
  isInLobby?: boolean
}

defineProps<PlayersWrapperProps>()

const gameStore = useGameStore()

const { players } = storeToRefs(gameStore)
</script>
<template>
  <div class="d-flex flex-row w-100 fill-height justify-center">
    <div class="d-flex flex-column justify-space-around align-center w-100">
      <Player :player="players[0]" :isInLobby="isInLobby" />
      <Player :player="players[1]" :isInLobby="isInLobby" />
    </div>
    <slot />
    <div class="d-flex flex-column justify-space-around align-center w-100">
      <Player :player="players[2]" :isInLobby="isInLobby" />
      <Player :player="players[3]" :isInLobby="isInLobby" />
    </div>
  </div>
</template>
