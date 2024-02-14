import { reactive } from 'vue'
import { Recipe } from './models/Recipe.js'


// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},

  /** @type {import('./models/Account.js').Account} */
  account: {},



  /** @type {Recipe[]} */
  recipes: [],

  /** @type {Recipe[]} */
  activeRecipe: []

})
