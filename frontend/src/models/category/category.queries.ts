import { keepPreviousData, useQuery } from '@tanstack/react-query'

import { categoryServiceKeys } from '~models/category/category.config'
import { CategoryRepository } from '~models/category/category.repository'
import { UseCategories } from '~models/category/category.types'

export const useCategories = (params?: Partial<UseCategories>) => {
	return useQuery({
		queryKey: [categoryServiceKeys.categories, params],
		queryFn: () => CategoryRepository.all(params),
		placeholderData: keepPreviousData,
	})
}

export const useCategory = (id: string) => {
	return useQuery({
		queryKey: [categoryServiceKeys.category, id],
		queryFn: () => CategoryRepository.getById(id),
		enabled: !!id,
	})
}
