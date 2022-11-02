<script>
import { Recipe } from "../models/Recipe.js";

export default {
  props: {
    recipe: {
      type: Recipe,
      required: true,
    },
  },
  setup() {
    return {};
  },
};
</script>

<template>
  <div
    class="card elevation-5 text-light"
    :style="`background-image: url(${recipe.img})`"
  >
    <div class="card-body">
      <div class="top">
        <p class="glass category">{{ recipe.category }}</p>
        <div class="favorite glass">
          <i v-if="!recipe.favoriteId" class="fa-regular fa-heart"></i>
          <i v-if="recipe.favoriteId" class="fa-solid fa-heart"></i>
        </div>
      </div>
      <div class="bottom glass">
        <h5 class="title">{{ recipe.title }}</h5>
        <p class="creator">{{ recipe.creator.name }}</p>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
p {
  margin: 0;
}

.card {
  width: 100%;
  padding-top: 100%;
  position: relative;

  background-position: center;
  background-size: cover;
  border: none;

  // @media (max-width: 900px) {
  //   width: 80%;
  //   padding-top: 80%;
  // }

  .card-body {
    position: absolute;
    top: 0;
    left: 0;
    bottom: 0;
    right: 0;

    display: flex;
    flex-direction: column;
    justify-content: space-between;

    .top {
      display: flex;
      justify-content: space-between;

      font-size: 1.15rem;
      .category {
        padding: 0.25rem 0.5rem;
        border-radius: 1rem;
        letter-spacing: 0.03rem;
      }

      .favorite {
        height: fit-content;
        padding-inline: 0.25rem;
        border-radius: 0.25rem;
      }
    }

    .bottom {
      padding: 0.5rem 0.8rem;
      border-radius: 0.5rem;

      .title {
        letter-spacing: 0.08rem;
      }

      .creator {
        letter-spacing: 0.03rem;
      }
    }
  }

  .glass {
    background-color: rgba(0, 0, 0, 0.45);
    backdrop-filter: blur(10px);
    text-shadow: 0.125rem 0.15rem 0.188rem rgba(0, 0, 0, 0.5);
  }
}
</style>
