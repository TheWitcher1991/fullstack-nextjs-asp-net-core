import { keepPreviousData, useQuery } from '@tanstack/react-query'
import { useEffect, useState } from 'react'

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

export const useSelectableCategories = () => {
	const [categories, setCategories] = useState<
		{ value: string; content: string }[]
	>([])
	const { isLoading, data } = useCategories()

	useEffect(() => {
		if (!isLoading && data?.data) {
			setCategories(
				data.data.result.map(category => ({
					value: category.id.toString(),
					content: category.title,
				})),
			)
		}
	}, [isLoading, data])

	return {
		categories,
		setCategories,
	}
}
