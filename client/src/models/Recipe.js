export class Recipe {
    constructor(data) {
        this.id = data.id
        this.title = data.title
        this.img = data.img
        this.category = data.category
        this.instructions = data.description

        this.creatorId = data.creatorId //do I need this?
        this.creator = data.creator //or this?

        this.createdAt = new Date(data.createdAt)
        this.updatedAt = new Date(data.updatedAt)
    }
}