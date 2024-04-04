import { Recipe } from "./Recipe.js"

export class Favorite extends Recipe {
    constructor(data) {
        super(data)
        this.favoriteId = data.favoriteId
    }
}