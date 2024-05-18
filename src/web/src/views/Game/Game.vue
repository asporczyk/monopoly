<script setup lang="ts">
import Board from '@/views/Game/Board.vue'
import PlayersBoardWrapper from '@/views/Game/Players/PlayersBoardWrapper.vue'
import GameActions from '@/views/Game/GameActions.vue'
</script>
<template>
  <PlayersBoardWrapper>
    <Board />
  </PlayersBoardWrapper>
  <GameActions />
</template>
