import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'
import { createI18n, useI18n } from 'vue-i18n'
import messages from '@intlify/unplugin-vue-i18n/messages'

import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import { createVueI18nAdapter } from 'vuetify/locale/adapters/vue-i18n'
import { aliases, mdi } from 'vuetify/iconsets/mdi'
import '@mdi/font/css/materialdesignicons.css'

export const i18n = createI18n({
  legacy: false,
  globalInjection: true,
  fallbackLocale: 'en',
  locale: navigator.language,
  missingWarn: false,
  fallbackWarn: false,
  messages,
})

const vuetify = createVuetify({
  locale: {
    adapter: createVueI18nAdapter({ i18n, useI18n }),
  },
  components,
  directives,
  theme: {
    defaultTheme: localStorage.getItem('theme') ?? 'light',
  },
  icons: {
    defaultSet: 'mdi',
    aliases,
    sets: {
      mdi,
    },
  },
})

createApp(App)
  .use(createPinia())
  .use(router)
  .use(vuetify)
  .use(i18n)
  .mount('#app')
