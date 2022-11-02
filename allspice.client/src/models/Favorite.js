export class Favorite {
  constructor(data) {
    this.id = data.Id;
    this.createdAt = data.CreatedAt;
    this.updatedAt = data.UpdatedAt;
    this.accountId = data.AccountId;
    this.recipeId = data.RecipeId;
  }
}
