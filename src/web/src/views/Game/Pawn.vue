<script setup lang="ts">
interface PawnProps {
  position: number
  color: string
}

defineProps<PawnProps>()
</script>
<template>
  <div class="pawn">
    <v-icon
      icon="mdi-circle"
      :color="color"
      :class="`position-absolute position-${position}`"
    />
  </div>
</template>
<style scoped lang="scss">
.position-0 {
  // Corner Bottom Right
  bottom: 40px;
  right: 40px;
}
.position-1 {
  bottom: 40px;
  right: 124px;
}
.position-2 {
  bottom: 40px;
  right: 185px;
}
.position-3 {
  bottom: 40px;
  right: 246px;
}
.position-4 {
  bottom: 40px;
  right: 307px;
}
.position-5 {
  bottom: 40px;
  right: 368px;
}
.position-6 {
  bottom: 40px;
  right: 429px;
}
.position-7 {
  bottom: 40px;
  right: 490px;
}
.position-8 {
  bottom: 40px;
  right: 551px;
}
.position-9 {
  bottom: 40px;
  right: 612px;
}
.position-10 {
  // Corner Bottom Left
  bottom: 40px;
  right: 695px;
}
.position-11 {
  bottom: 124px;
  right: 695px;
}
.position-12 {
  bottom: 185px;
  right: 695px;
}
.position-13 {
  bottom: 246px;
  right: 695px;
}
.position-14 {
  bottom: 307px;
  right: 695px;
}
.position-15 {
  bottom: 368px;
  right: 695px;
}
.position-16 {
  bottom: 429px;
  right: 695px;
}
.position-17 {
  bottom: 490px;
  right: 695px;
}
.position-18 {
  bottom: 551px;
  right: 695px;
}
.position-19 {
  bottom: 612px;
  right: 695px;
}
.position-20 {
  // Corner Top Left
  bottom: 695px;
  right: 695px;
}
.position-21 {
  bottom: 695px;
  right: 612px;
}
.position-22 {
  bottom: 695px;
  right: 551px;
}
.position-23 {
  bottom: 695px;
  right: 490px;
}
.position-24 {
  bottom: 695px;
  right: 429px;
}
.position-25 {
  bottom: 695px;
  right: 368px;
}
.position-26 {
  bottom: 695px;
  right: 307px;
}
.position-27 {
  bottom: 695px;
  right: 246px;
}
.position-28 {
  bottom: 695px;
  right: 185px;
}
.position-29 {
  bottom: 695px;
  right: 124px;
}
.position-30 {
  // Corner Top Right
  bottom: 695px;
  right: 40px;
}
.position-31 {
  bottom: 612px;
  right: 40px;
}
.position-32 {
  bottom: 551px;
  right: 40px;
}
.position-33 {
  bottom: 490px;
  right: 40px;
}
.position-34 {
  bottom: 429px;
  right: 40px;
}
.position-35 {
  bottom: 368px;
  right: 40px;
}
.position-36 {
  bottom: 307px;
  right: 40px;
}
.position-37 {
  bottom: 246px;
  right: 40px;
}
.position-38 {
  bottom: 185px;
  right: 40px;
}
.position-39 {
  bottom: 124px;
  right: 40px;
}
</style>
