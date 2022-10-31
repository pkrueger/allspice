<template>
  <main class="bg-light">
    <router-view />
  </main>
</template>

<script>
import { computed } from "vue";
import { AppState } from "./AppState";
import Navbar from "./components/Navbar.vue";

export default {
  setup() {
    return {
      appState: computed(() => AppState),
    };
  },
  components: { Navbar },
};
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

main {
  padding: 1.5rem;
}

.text-shadow {
  text-shadow: 0.1rem 0.1rem 0.3rem rgba(0, 0, 0, 0.5);
}
</style>
