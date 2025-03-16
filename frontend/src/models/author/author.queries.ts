import { keepPreviousData, useQuery } from '@tanstack/react-query'
import { useEffect, useState } from 'react'

import { authorServiceKeys } from '~models/author/author.config'
import { AuthorRepository } from '~models/author/author.repository'
import { UseAuthors } from '~models/author/author.types'

export const useAuthors = (params?: Partial<UseAuthors>) => {
	return useQuery({
		queryKey: [authorServiceKeys.authors, params],
		queryFn: () => AuthorRepository.all(params),
		placeholderData: keepPreviousData,
	})
}

export const useAuthor = (id: string) => {
	return useQuery({
		queryKey: [authorServiceKeys.author, id],
		queryFn: () => AuthorRepository.getById(id),
		enabled: !!id,
	})
}

export const useSelectableAuthors = () => {
	const [authors, setAuthors] = useState<
		{ value: string; content: string }[]
	>([])
	const { isLoading, data } = useAuthors()

	useEffect(() => {
		if (!isLoading && data?.data) {
			setAuthors(
				data.data.result.map(author => ({
					value: author.id.toString(),
					content: author.fullName,
				})),
			)
		}
	}, [isLoading, data])

	return {
		authors,
		isLoading,
	}
}
