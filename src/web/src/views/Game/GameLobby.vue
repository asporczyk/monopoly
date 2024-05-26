<script setup lang="ts">
import PlayersWrapper from '@/views/Game/Players/PlayersWrapper.vue'
import { connection } from '@/api/SignalRConnection'
import { useGameStore } from '@/stores/game'
import TextButtonWithIcon from '@/components/atoms/Buttons/TextButtonWithIcon.vue'
import { useI18n } from 'vue-i18n'
import { storeToRefs } from 'pinia'
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import router from '@/router'

const gameStore = useGameStore()

const { areAllPlayersReady } = storeToRefs(gameStore)

const { t } = useI18n()

connection.on('PlayerJoined', (data) => {
  gameStore.setPlayers(data.players)
})

const ready = () => {
  connection.invoke('Ready')
}

connection.on('PlayerReady', (data) => {
  console.log(data)
  gameStore.setPlayerReady(data.id)
})

const start = () => {
  connection.invoke('StartGame')
}

connection.on('PlayersNotReady', () => {
  gameStore.setAreAllPlayersReady(false)
})

connection.on('GameAlreadyStarted', () => {
  console.log('Game already started')
})

connection.on('GameStarted', () => {
  router.push('game')
})
</script>
<template>
  <div class="d-flex flex-column align-center w-100">
    <PlayersWrapper isInLobby />
    <TextButtonWithIcon
      icon="mdi-check"
      variant="positive"
      force-text
      @click="ready"
      >{{ t('ready') }}
    </TextButtonWithIcon>
    <TextButton v-if="areAllPlayersReady" variant="primary" @click="start">{{
      t('start')
    }}</TextButton>
  </div>
</template>
<i18n>
{
  "en": {
    "ready": "Ready",
    "start": "Start"
  },
  "pl": {
    "ready": "Gotowy",
    "start": "Start"
  }
}
</i18n>
