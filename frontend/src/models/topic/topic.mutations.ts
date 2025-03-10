import { useMutation } from '@tanstack/react-query'

import { topicServiceKeys } from '~models/topic/topic.config'
import { TopicRepository } from '~models/topic/topic.repository'
import { ICreateTopic, IUpdateTopic } from '~models/topic/topic.types'

import { optimisticInvalidateQueries } from '~packages/lib'

export const useCreateTopic = () => {
	return useMutation({
		mutationFn: (data: ICreateTopic) => TopicRepository.create(data),
		onSettled: async () => {
			await optimisticInvalidateQueries([[topicServiceKeys.topics]])
		},
	})
}

export const useUpdateTopic = (id: string) => {
	return useMutation({
		mutationFn: (data: IUpdateTopic) => TopicRepository.update(id, data),
		onSettled: async () => {
			await optimisticInvalidateQueries([
				[topicServiceKeys.topics],
				[topicServiceKeys.topic, id],
			])
		},
	})
}

export const useDeleteTopic = () => {
	return useMutation({
		mutationFn: (id: string) => TopicRepository.delete(id),
		onSettled: async () => {
			await optimisticInvalidateQueries([[topicServiceKeys.topics]])
		},
	})
}
