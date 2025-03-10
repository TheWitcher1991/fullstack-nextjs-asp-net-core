import { keepPreviousData, useQuery } from '@tanstack/react-query'

import { bookServiceKeys } from '~models/book/book.config'
import { BookRepository } from '~models/book/book.repository'
import { UseBooks } from '~models/book/book.types'

export const useBooks = (params?: Partial<UseBooks>) => {
	return useQuery({
		queryKey: [bookServiceKeys.books, params],
		queryFn: () => BookRepository.all(params),
		placeholderData: keepPreviousData,
	})
}

export const useBooksByTopic = (params?: Partial<UseBooks>) => {
	return useQuery({
		queryKey: [bookServiceKeys.booksByTopic, params],
		queryFn: () => BookRepository.getByTopic(params),
		placeholderData: keepPreviousData,
	})
}

export const useBook = (id: string) => {
	return useQuery({
		queryKey: [bookServiceKeys.book, id],
		queryFn: () => BookRepository.getById(id),
		enabled: !!id,
	})
}
