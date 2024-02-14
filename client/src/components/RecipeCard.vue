<template>
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="card">
                    <img v-if="recipe" class="card-img-top" :src="recipe.img" alt="Recipe image">

                    <div class="card-body">
                        <h5 class="card-title">{{ recipe.title }}</h5>
                        <p class="card-text">{{ recipe.category }}</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { Recipe } from '../models/Recipe.js';

export default {
    props: {
        recipe: {
            type: Recipe,
            required: true,
            default: () => ({ img: '', title: '', category: '' })
        }
    },

};
</script>

<style lang="scss" scoped>
.card {
    border-radius: 15px;
    overflow: hidden;

    img {
        height: 15vh;
        object-fit: cover;
        object-position: center;
        border-top-right-radius: 16px;
        border-top-left-radius: 16px;
    }
}
</style>




