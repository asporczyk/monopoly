<script setup lang="ts">
import BasicModal from '@/components/atoms/BasicModal/BasicModal.vue'
import CenteredBox from '@/components/molecules/CenteredBox/CenteredBox.vue'
import IconButton from '@/components/atoms/Buttons/IconButton.vue'
import HeadlineM from '@/components/atoms/Typography/HeadlineM.vue'
import TextBody from '@/components/atoms/Typography/TextBody.vue'

defineProps<{ height?: string; width?: string; maxWidth?: string }>()
defineEmits(['on-close'])
</script>
<template>
  <BasicModal>
    <CenteredBox
      :width="width ?? 'auto'"
      :height="height ?? 'auto'"
      :max-width="maxWidth"
    >
      <div class="position-absolute align-self-end">
        <IconButton icon="mdi-close" @click="$emit('on-close')" />
      </div>
      <div class="d-flex flex-column align-center fill-height px-lg-5">
        <HeadlineM class="mx-2 my-2 text-center">
          <slot name="title" />
        </HeadlineM>
        <TextBody
          class="mx-5 mb-10 d-flex flex-column justify-space-between fill-height text-center"
        >
          <slot name="body" />
        </TextBody>
      </div>
    </CenteredBox>
  </BasicModal>
</template>
