<template>
  <div class="home flex-grow-1">
    <div class="hero-image mb-4"
      style="background-image: url('https://images.unsplash.com/photo-1556909211-36987daf7b4d?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8cmVjaXBlc3xlbnwwfHwwfHx8MA%3D%3D');">
    </div>

    <div class="container">
      <div class="row">
        <div class="col-md-4" v-for="recipe in recipes" :key="recipe.id">
          <div class="card">
            <img class="card-img-top" :src="recipe.imageUrl" alt="Recipe image">
            <div class="card-body">
              <h5 class="card-title">{{ recipe.title }}</h5>
              <p class="card-text">{{ recipe.description }}</p>
              <a href="#" class="btn btn-primary">View Recipe</a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  setup() {
    const recipes = [
      { id: 1, title: 'Recipe 1', description: 'This is a description for Recipe 1', imageUrl: 'link_to_image_1.jpg' },
      { id: 2, title: 'Recipe 2', description: 'This is a description for Recipe 2', imageUrl: 'link_to_image_2.jpg' },
      { id: 3, title: 'Recipe 3', description: 'This is a description for Recipe 3', imageUrl: 'link_to_image_3.jpg' }
    ];

    return {
      recipes
    }
  }
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
