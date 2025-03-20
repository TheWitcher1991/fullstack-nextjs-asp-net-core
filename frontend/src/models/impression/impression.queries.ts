import { keepPreviousData, useQuery } from '@tanstack/react-query'

import { impressionServiceKeys } from '~models/impression/impression.config'
import { ImpressionRepository } from '~models/impression/impression.repository'
import { UseImpressions } from '~models/impression/impression.types'

export const useImpressions = (
	bookId: string,
	params?: Partial<UseImpressions>,
) => {
	return useQuery({
		queryKey: [impressionServiceKeys.impressionsByBook, bookId, params],
		queryFn: () => ImpressionRepository.getByBook(bookId, params),
		placeholderData: keepPreviousData,
	})
}

export const useImpressionsByUser = (
	userId: string,
	params?: Partial<UseImpressions>,
) => {
	return useQuery({
		queryKey: [impressionServiceKeys.impressionsByUser, userId, params],
		queryFn: () => ImpressionRepository.getByUser(userId, params),
		placeholderData: keepPreviousData,
	})
}

export const useImpression = (id: string) => {
	return useQuery({
		queryKey: [impressionServiceKeys.impression, id],
		queryFn: () => ImpressionRepository.getById(id),
		enabled: !!id,
	})
}
