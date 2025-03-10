import { BASE_ROOT_URL } from '~packages/system'

const links = {
	get root() {
		return BASE_ROOT_URL
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

	get search() {
		return `${this.root}search`
	},

	get notFound() {
		return `${this.root}404`
	},

	get profile() {
		return `${this.root}profile`
	},

	books: {
		get index() {
			return `${BASE_ROOT_URL}books`
		},
		get create() {
			return `${this.index}/create`
		},
		edit(id: number) {
			return `${this.index}/${id}/edit`
		},
		byId(id?: number) {
			return `${this.index}/${id}`
		},
	},
}

export default links
