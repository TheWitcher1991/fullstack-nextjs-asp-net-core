'use client'

import { Select, Skeleton } from '@gravity-ui/uikit'
import { FieldPath, UseFormRegister } from 'react-hook-form'

import { useSelectableTopics } from '~models/topic'

interface TopicSelectProps<T = any> {
	defaultValue?: string[]
	value?: string[]
	errorMessage?: string
	onSelect: (value: string[]) => void
	register: UseFormRegister<T>
}

export function TopicSelect<T = any>({
	defaultValue,
	value,
	errorMessage,
	onSelect,
	register,
}: TopicSelectProps<T>) {
	const { isLoading, topics } = useSelectableTopics()

	return isLoading ? (
		<Skeleton
			style={{
				height: 35,
			}}
		/>
	) : (
		<>
			<Select
				defaultValue={defaultValue || []}
				value={value || []}
				hasClear={true}
				name={'topics'}
				ref={register('topics' as FieldPath<T>).ref}
				errorMessage={errorMessage}
				width={'max'}
				size={'l'}
				filterable={true}
				placeholder={'Выберите жанр'}
				options={topics}
				validationState={errorMessage ? 'invalid' : undefined}
				onUpdate={onSelect}
			/>
		</>
	)
}
