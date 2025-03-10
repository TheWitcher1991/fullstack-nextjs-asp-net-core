import { useMutation } from '@tanstack/react-query'

import { bookServiceKeys } from '~models/book/book.config'
import { BookRepository } from '~models/book/book.repository'

import { optimisticInvalidateQueries } from '~packages/lib'

export const useCreateBook = () => {
	return useMutation({
		mutationFn: ({
			data,
			onUploadProgress,
		}: {
			data: FormData
			onUploadProgress?: OnUploadProgress
		}) => BookRepository.createFormData(data, onUploadProgress),
		onSettled: async () => {
			await optimisticInvalidateQueries([
				[bookServiceKeys.books],
				[bookServiceKeys.infiniteBooks],
			])
		},
	})
}

export const useUpdateBook = (id: string) => {
	return useMutation({
		mutationFn: ({
			data,
			onUploadProgress,
		}: {
			data: FormData
			onUploadProgress?: OnUploadProgress
		}) => BookRepository.updateFormData(id, data, onUploadProgress),
		onSettled: async () => {
			await optimisticInvalidateQueries([
				[bookServiceKeys.book, id],
				[bookServiceKeys.books],
				[bookServiceKeys.booksByTopic],
				[bookServiceKeys.infiniteBooks],
			])
		},
	})
}

export const useDeleteBook = () => {
	return useMutation({
		mutationFn: (id: string) => BookRepository.delete(id),
		onSettled: async () => {
			await optimisticInvalidateQueries([
				[bookServiceKeys.books],
				[bookServiceKeys.booksByTopic],
				[bookServiceKeys.infiniteBooks],
			])
		},
	})
}
