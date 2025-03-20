import { keepPreviousData, useQuery } from '@tanstack/react-query'

import { emotionServiceKeys } from '~models/emotion/emotion.config'
import { EmotionRepository } from '~models/emotion/emotion.repository'
import { UseEmotions } from '~models/emotion/emotion.types'

export const useEmotions = (params?: Partial<UseEmotions>) => {
	return useQuery({
		queryKey: [emotionServiceKeys.emotions, params],
		queryFn: () => EmotionRepository.all(params),
		placeholderData: keepPreviousData,
	})
}

export const useEmotion = (id: string) => {
	return useQuery({
		queryKey: [emotionServiceKeys.emotion, id],
		queryFn: () => EmotionRepository.getById(id),
		enabled: !!id,
	})
}
