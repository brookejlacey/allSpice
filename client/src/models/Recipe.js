export class Recipe {
    constructor(data) {
        this.id = data.id
        this.creatorId = data.creatorId //do I need this?
        this.title = data.title
        this.img = data.img
        this.category = data.category
        this.instructions = data.description

        this.creator = data.creator //do I need this?

        this.createdAt = new Date(data.createdAt)
        this.updatedAt = new Date(data.updatedAt)
    }
}