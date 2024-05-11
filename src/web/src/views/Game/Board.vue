<script setup lang="ts">
import Pawn from '@/views/Game/Pawn.vue'
import { useGameStore } from '@/stores/game'
import { storeToRefs } from 'pinia'

const gameStore = useGameStore()
const { players } = storeToRefs(gameStore)
</script>
<template>
  <div class="board">
    <Pawn
      v-for="player in players"
      v-bind:key="player.id"
      :color="player.color"
      :position="player.position"
    />
  </div>
</template>
<style lang="scss">
.board {
  position: relative;
  width: auto;
  height: auto;
  max-height: 90vh;
  aspect-ratio: 1/1;
  background-image: url('@/assets/svg/monopoly-board.svg');
}
</style>
