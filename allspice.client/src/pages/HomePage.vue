<script>
import { onMounted, reactive } from "vue";
import RecipeCard from "../components/RecipeCard.vue";
import Login from "../components/Login.vue";
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { recipesService } from "../services/RecipesService.js";

export default {
  setup() {
    const state = reactive({
      activeFilter: computed(() => AppState.activeFilter),
      recipes: computed(() => AppState.recipes),
      favoriteRecipes: computed(() =>
        AppState.recipes.filter((r) => {
          for (let f of AppState.favorites) {
            if (f.recipeId == r.id) {
              return true;
            }
          }
        })
      ),
    });

    onMounted(() => {
      getAllRecipes();
    });

    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes();
      } catch (error) {
        Pop.error(error, "[GetAllRecipes]");
      }
    }

    function changeFilter(filter) {
      try {
        recipesService.changeFilter(filter);
      } catch (error) {
        Pop.error(error, "[ChangeFilter]");
      }
    }

    return { state, changeFilter };
  },
  components: { RecipeCard, Login },
};
</script>

<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12 banner elevation-5">
        <div class="top-banner">
          <div class="search-bar">
            <div class="input-group mb-3">
              <input
                type="text"
                class="form-control"
                placeholder="Search..."
                aria-label="Search for recipe."
                aria-describedby="search-button"
              />
              <!-- TODO put basic button here for search bar -->
            </div>
          </div>
          <div class="login">
            <Login />
          </div>
        </div>
        <div class="banner-text text-light text-shadow no-select">
          <h2 class="main">All-Spice</h2>
          <h5 class="sub">Cherish Your Family And Their Cooking</h5>
        </div>
        <div class="filter-buttons bg-white shadow text-success">
          <div class="filter-button-container">
            <h5
              :class="state.activeFilter == 'Home' ? 'active-filter' : ''"
              class="filter-button no-select"
              @click="changeFilter('Home')"
            >
              Home
            </h5>
          </div>
          <div class="filter-button-container">
            <h5
              :class="state.activeFilter == 'My Recipes' ? 'active-filter' : ''"
              class="filter-button no-select"
              @click="changeFilter('My Recipes')"
            >
              My Recipes
            </h5>
          </div>
          <div class="filter-button-container">
            <h5
              :class="state.activeFilter == 'Favorites' ? 'active-filter' : ''"
              class="filter-button no-select"
              @click="changeFilter('Favorites')"
            >
              Favorites
            </h5>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div class="container-fluid content">
    <div class="row">
      <div class="col-12 p-0">
        <div class="recipes">
          <RecipeCard v-for="r in state.recipes" :key="r.id" :recipe="r" />
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
.banner {
  background-image: url("banner.png");
  background-position: center;
  background-size: cover;
  width: 100%;
  height: 21rem;
  position: relative;
  border-radius: 0.5rem;
  margin-bottom: 6rem;

  .top-banner {
    position: absolute;
    right: 0;
    top: 0;
    display: flex;
    gap: 1rem;
    margin: 1rem;
  }

  .banner-text {
    position: absolute;
    margin-left: auto;
    margin-right: auto;
    left: 0;
    right: 0;
    bottom: 50%;
    transform: translateY(50%);
    text-align: center;

    .main {
      font-weight: 700;
      letter-spacing: 0.075rem;
    }
    .sub {
      font-weight: 600;
      letter-spacing: 0.04rem;
    }
  }

  .filter-buttons {
    --button-paddingX: 1.75rem;
    --button-paddingY: 0.75rem;
    display: flex;
    justify-content: center;
    flex-wrap: wrap;
    align-items: center;
    gap: var(--button-paddingX);
    position: absolute;
    left: 50%;
    bottom: -7.5%;
    transform: translateX(-50%);
    text-align: center;
    padding: var(--button-paddingY) var(--button-paddingX);
    border-radius: 0.25rem;

    .filter-button {
      width: 7rem;
      margin-bottom: 0;
      padding: 0.5rem 0;
      cursor: pointer;
    }

    // .filter-button-container:hover .filter-button {
    //   transform: translateY(-0.25rem);
    //   box-shadow: 0 0.25rem 0.2rem -0.25rem rgba(0, 0, 0, 0.5);
    // }

    .active-filter {
      border-bottom: 0.2rem solid #219653;
      padding-bottom: 0.3rem;
    }
  }
}

.content {
  .recipes {
    display: grid;
    gap: 6rem;
    grid-template-columns: repeat(3, 1fr);
    padding-inline: 5rem;
  }

  @media (max-width: 1300px) {
    .recipes {
      grid-template-columns: repeat(2, 1fr);
    }
  }

  @media (max-width: 900px) {
    .recipes {
      gap: 3rem;
      padding-inline: 2rem;
    }
  }

  @media (max-width: 700px) {
    .recipes {
      grid-template-columns: repeat(1, 1fr);
      padding-inline: 5rem;
    }
  }

  @media (max-width: 500px) {
    .recipes {
      padding-inline: 2rem;
    }
  }
}

.text-shadow {
  text-shadow: 0.125rem 0.15rem 0.188rem rgba(0, 0, 0, 0.5);
}
</style>
