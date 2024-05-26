<script setup lang="ts">
import Board from '@/views/Game/Board.vue'
import PlayersWrapper from '@/views/Game/Players/PlayersWrapper.vue'
import GameActions from '@/views/Game/GameActions.vue'
</script>
<template>
  <PlayersWrapper>
    <Board />
  </PlayersWrapper>
  <GameActions />
</template>
