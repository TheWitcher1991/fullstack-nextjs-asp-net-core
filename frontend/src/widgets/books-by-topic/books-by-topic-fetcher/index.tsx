import { useEffect } from 'react'

import { useBooksByTopicStore } from '~widgets/books-by-topic/books-by-topic.store'

import { useBooksByTopic } from '~models/book'

export default function BooksByTopicFetcher() {
	const { setLoading, setList, setCount, filter } = useBooksByTopicStore()
	const { isLoading, data } = useBooksByTopic(filter)

	useEffect(() => {
		setLoading(isLoading)
		if (!isLoading && data?.data) {
			setList(data.data.result)
			setCount(data.data.result.length)
		}
	}, [isLoading, data])

	return null
}
