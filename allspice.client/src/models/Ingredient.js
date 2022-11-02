export class Ingredient {
  constructor(data) {
    this.id = data.Id;
    this.createdAt = data.CreatedAt;
    this.updatedAt = data.UpdatedAt;
    this.name = data.Name;
    this.quantity = data.Quantity;
    this.recipeId = data.RecipeId;
  }
}
