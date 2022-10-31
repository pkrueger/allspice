<template>
  <button
    class="btn btn-success selectable text-light text-uppercase m-2"
    @click="login"
    v-if="!user.isAuthenticated"
  >
    Login
  </button>
  <div v-else>
    <div class="dropdown m-2">
      <div
        type="button"
        class="border-0 selectable no-select"
        data-bs-toggle="dropdown"
        aria-expanded="false"
      >
        <div v-if="account.picture || user.picture" class="photo-container">
          <img
            :src="account.picture || user.picture"
            alt="account photo"
            height="55"
            class="photo"
          />
        </div>
      </div>
      <div
        class="dropdown-menu dropdown-menu-end p-0"
        aria-labelledby="authDropdown"
      >
        <div class="list-group">
          <router-link :to="{ name: 'Account' }">
            <div class="list-group-item dropdown-item list-group-item-action">
              Manage Account
            </div>
          </router-link>
          <div
            class="list-group-item dropdown-item list-group-item-action text-danger selectable"
            @click="logout"
          >
            <i class="mdi mdi-logout"></i>
            logout
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from "vue";
import { AppState } from "../AppState";
import { AuthService } from "../services/AuthService";
export default {
  setup() {
    return {
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      async login() {
        AuthService.loginWithPopup();
      },
      async logout() {
        AuthService.logout({ returnTo: window.location.origin });
      },
    };
  },
};
</script>

<style lang="scss" scoped>
.photo-container {
  border-radius: 50%;
  overflow: hidden;
  .photo {
    object-fit: cover;
    object-position: center;
  }
}
</style>
