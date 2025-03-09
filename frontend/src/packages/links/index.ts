const links = {
	get root() {
		return '/'
	},

	get home() {
		return this.root
	},

	get login() {
		return `${this.root}login`
	},

	get register() {
		return `${this.root}register`
	},

	get logout() {
		return `${this.root}logout`
	},

	get notFound() {
		return `${this.root}404`
	},
}

export default links
