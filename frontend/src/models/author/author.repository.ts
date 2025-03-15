import { authorServiceKeys } from '~models/author/author.config'
import {
	IAuthor,
	ICreateAuthor,
	IUpdateAuthor,
	UseAuthors,
} from '~models/author/author.types'

import { http } from '~packages/lib'
import { CrudRepository } from '~packages/mixins'

const AuthorRepositoryBuilder = () => {
	return new CrudRepository<
		IAuthor[],
		IAuthor,
		ICreateAuthor,
		IUpdateAuthor,
		UseAuthors
	>(http.instance, authorServiceKeys.authors)
}

export const AuthorRepository = AuthorRepositoryBuilder()
