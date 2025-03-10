import { useMutation } from '@tanstack/react-query'

import { categoryServiceKeys } from '~models/category/category.config'
import { CategoryRepository } from '~models/category/category.repository'
import {
	ICreateCategory,
	IUpdateCategory,
} from '~models/category/category.types'

import { optimisticInvalidateQueries } from '~packages/lib'

export const useCreateCategory = () => {
	return useMutation({
		mutationFn: (data: ICreateCategory) => CategoryRepository.create(data),
		onSettled: async () => {
			await optimisticInvalidateQueries([
				[categoryServiceKeys.categories],
			])
		},
	})
}

export const useUpdateCategory = (id: string) => {
	return useMutation({
		mutationFn: (data: IUpdateCategory) =>
			CategoryRepository.update(id, data),
		onSettled: async () => {
			await optimisticInvalidateQueries([
				[categoryServiceKeys.categories],
				[categoryServiceKeys.category, id],
			])
		},
	})
}

export const useDeleteCategory = () => {
	return useMutation({
		mutationFn: (id: string) => CategoryRepository.delete(id),
		onSettled: async () => {
			await optimisticInvalidateQueries([
				[categoryServiceKeys.categories],
			])
		},
	})
}
