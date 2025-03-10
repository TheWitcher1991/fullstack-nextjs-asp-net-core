import { keepPreviousData, useQuery } from '@tanstack/react-query'

import { topicServiceKeys } from '~models/topic/topic.config'
import { TopicRepository } from '~models/topic/topic.repository'
import { UseTopics } from '~models/topic/topic.types'

export const useTopics = (params?: Partial<UseTopics>) => {
	return useQuery({
		queryKey: [topicServiceKeys.topics, params],
		queryFn: () => TopicRepository.all(params),
		placeholderData: keepPreviousData,
	})
}

export const useTopic = (id: string) => {
	return useQuery({
		queryKey: [topicServiceKeys.topic, id],
		queryFn: () => TopicRepository.getById(id),
		enabled: !!id,
	})
}
