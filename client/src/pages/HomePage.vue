<template>
  <div class="home flex-grow-1">
    <div class="hero-image mb-4"
      style="background-image: url('https://images.unsplash.com/photo-1556909211-36987daf7b4d?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8cmVjaXBlc3xlbnwwfHwwfHx8MA%3D%3D');">
    </div>
  </div>

  <button class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#create-recipe-modal">New Recipe<i
      class="mdi mdi-plus-circle"></i>
  </button>
  <!-- <NewRecipeForm /> -->

  <section class="row">
    <div class="col-6 col-md-3" v-for="recipe in recipes" :key="recipe.id">
      <RecipeCard :recipe="recipe" />
    </div>
  </section>
</template>

<script>

import { computed, onMounted, popScopeId, ref } from 'vue';
import { AppState } from '../AppState';
import { recipesService } from '../services/RecipesService.js';
import NewRecipeForm from '../components/RecipeCard.vue';
import Pop from '../utils/Pop';
import { Modal } from 'bootstrap';
import RecipeCard from '../components/RecipeCard.vue';


export default {
  setup() {
    onMounted(() => {
      getAllRecipes();
    })
    // const filterby = ref('')
    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes()
      } catch (error) {
        Pop.error(error)
      }
    }
    return {
      recipes: computed(() => {
        return AppState.recipes
      })
    }
  },

  //   filterby,
  //   recipes: computed(() => {
  //     if (filterby.value) {
  //       return AppState.recipes.filter(e => e.type == filterby.value)
  //     } else {
  //       return AppState.recipes
  //     }
  //   })
  // };
  components: { NewRecipeForm, RecipeCard }
}

</script>

<style scoped lang="scss">
.hero-image {
  width: 100%;
  height: 200px;
  background-size: cover;
  background-position: center;
}
</style>
