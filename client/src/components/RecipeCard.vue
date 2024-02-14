<template>
    <div class="container">
        <div class="row">
            <div class="col-md-4" v-for="recipe in recipes" :key="recipe.id">
                <div class="card" selectable>
                    <img class="card-img-top" :src="recipe.imageUrl" alt="Recipe image">
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
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Recipe } from '../models/Recipe';

export default {
    props: { recipe: { type: Recipe, required: true } },
    setup() {
        return {}
    }
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