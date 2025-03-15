import { keepPreviousData, useQuery } from '@tanstack/react-query'
import { useEffect, useState } from 'react'

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

export const useSelectableTopics = () => {
	const [topics, setTopics] = useState<{ value: string; content: string }[]>(
		[],
	)
	const { isLoading, data } = useTopics()

	useEffect(() => {
		if (!isLoading && data?.data) {
			setTopics(
				data.data.result.map(topic => ({
					value: topic.id.toString(),
					content: topic.title,
				})),
			)
		}
	}, [isLoading, data])

	return {
		topics,
		isLoading,
	}
}
