<template>
    <div class="modal fade" id="create-recipe-modal" tabindex="-1" role="dialog" aria-labelledby="modalNameId"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body container-fluid">
                    <h4 class="text-primary p-2">New Recipe</h4>

                    <form class="row">
                        @submit.prevent="createRecipe()
                        <div class="mb-3 col-6">
                            <label for="recipe-title">Title</label>
                            <input v-model="recipeData.title" class="form-control" type="text" name="recipe-title"
                                id="create-recipe-title" required minlength="3" maxlength="30">
                        </div>

                        <div class="mb-3 col-6">
                            <label for="recipe-image">Recipe Image Link</label>
                            <input v-model="recipeData.img" class="form-control" type="url" name="recipe-image"
                                id="create-recipe-image" maxlength="500">
                        </div>

                        <div class="mb-3 col-6">
                            <label for="recipe-title">Category</label>
                            <select v-model="recipeData.category" class="form-control" name="recipe-title"
                                id="create-recipe-title">
                                <option selected disabled value="">select a category</option>
                                <option v-for="option in categoryOptions" :value="option">{{ option }}</option>
                            </select>
                        </div>

                        <div class="mb-3 col-6">
                            <label for="recipe-instructions">Instructions</label>
                            <input v-model="recipeData.instructions" class="form-control" type="text"
                                name="recipe-instructions" id="recipe-instructions" required>
                        </div>


                        <div class="mb-3 col-6 d-flex align-items-end justify-content-end">
                            <button class="btn btn-primary">Create <i class="mdi mdi-plus"></i></button>
                        </div>

                    </form>

                </div>

            </div>
        </div>
    </div>
</template>
  
  
<script>
import { useRouter } from 'vue-router';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';
import { ref } from 'vue';
import { Modal } from 'bootstrap';

export default {
    setup() {
        const recipeData = ref({
            title: '',
            img: '',
            instructions: '',
            category: '',
        });
        // const router = useRouter()
        return {
            recipeData,
            categoryOptions: ['Cheese', 'Italian', 'Soup', 'Mexican', 'Specialty Coffee'],


            async createRecipe() {
                try {
                    const recipe = await recipesService.createRecipe(recipeData.value);
                    Pop.success('recipe created');
                    recipeData.value = { title: '', img: '', instructions: '', category: '' };
                    Modal.getOrCreateInstance(document.getElementById('create-recipe-modal')).hide();
                } catch (error) {
                    Pop.error(error);
                }
            }
        }
    }
}

//             async createRecipe() {
//                 try {
//                     const recipe = await recipesService.createRecipe(recipeData.value)
//                     Pop.success('recipe created')
//                     recipeData.value = ref({})
//                     Modal.getOrCreateInstance('#create-recipe-modal').hide()
//                     router.push({ name: 'Recipe Details', params: { recipeId: recipe.id } })
//                 } catch (error) {
//                     Pop.error(error)
//                 }
//             }
//         }
//     }
// }

</script>
  
  
<style lang="scss" scoped></style>