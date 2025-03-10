import { categoryServiceKeys } from '~models/category/category.config'
import {
	ICategory,
	ICreateCategory,
	IUpdateCategory,
	UseCategories,
} from '~models/category/category.types'

import { http } from '~packages/lib'
import { CrudRepository } from '~packages/mixins'

const CategoryRepositoryBuilder = () => {
	return new CrudRepository<
		ICategory[],
		ICategory,
		ICreateCategory,
		IUpdateCategory,
		UseCategories
	>(http.instance, categoryServiceKeys.categories)
}

export const CategoryRepository = CategoryRepositoryBuilder()
