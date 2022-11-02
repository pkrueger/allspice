import { Account } from "./Account.js";

export class Recipe {
  constructor(data) {
    this.id = data.id;
    this.createdAt = data.createdAt;
    this.updatedAt = data.updatedAt;
    this.title = data.title;
    this.instructions = data.instructions;
    this.img = data.img;
    this.category = data.category;
    this.creatorId = data.creatorId;
    this.creator = new Account(data.creator);
    this.favoriteId = data.favoriteId;
  }
}
