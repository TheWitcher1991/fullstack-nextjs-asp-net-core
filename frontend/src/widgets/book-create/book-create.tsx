import { Plus } from '@gravity-ui/icons'
import { Button, Flex, Icon, TextArea, TextInput } from '@gravity-ui/uikit'
import { zodResolver } from '@hookform/resolvers/zod'
import { useRouter } from 'next/navigation'
import { FieldPath, useForm, UseFormWatch } from 'react-hook-form'
import toast from 'react-hot-toast'

import { account } from '~models/account'
import {
	CreateBookFormSchema,
	ICreateBookForm,
	useCreateBook,
} from '~models/book'
import { CategorySelect } from '~models/category'

import { useUploadProgress } from '~packages/hooks'
import { query } from '~packages/lib'
import links from '~packages/links'
import { BOOK_FILE_TYPES, IMAGE_FILE_TYPES } from '~packages/system'
import {
	FileButton,
	FormCard,
	FormSection,
	ImageButton,
	QueryProgress,
	Spacing,
} from '~packages/ui'

export default function BookCreate() {
	const router = useRouter()
	const { uploads, clearUploads, setUploads } = useUploadProgress()
	const {
		register,
		handleSubmit,
		formState: { errors },
		setValue,
		setError,
		reset,
		watch,
	} = useForm<ICreateBookForm>({
		defaultValues: {
			title: '',
			description: '',
			holder: '',
			author: '',
			translator: '',
			age: '',
			pages: '',
			user: account?.id,
		},
		resolver: zodResolver(CreateBookFormSchema),
	})
	const req = useCreateBook()

	const onSubmit = async (data: ICreateBookForm) => {
		const formData = new FormData()

		formData.append('title', data.title)
		formData.append('description', data.description)
		formData.append('publisher', data.publisher)
		formData.append('holder', data.holder)
		formData.append('translator', data.translator)
		formData.append('author', data.author)
		formData.append('age', data.age)
		formData.append('pages', data.pages)
		formData.append('categories', data.categories)
		formData.append('image', data.image)
		formData.append('file', data.file)
		formData.append('user', account?.id)

		await query(async () => {
			await req.mutateAsync({
				data: formData as FormData,
				onUploadProgress: (progress, uploaded, total) => {
					setUploads({
						progress,
						uploaded,
						total,
					})
				},
			})
			reset()
			clearUploads()
			toast.success('Книга успешно создана')
			router.replace(links.books.index)
		})
	}

	return (
		<FormCard width={'100%'}>
			<form onSubmit={handleSubmit(onSubmit)}>
				<FormSection label={'Категория'}>
					<CategorySelect
						value={String(
							watch(
								'categories' as UseFormWatch<ICreateBookForm>,
							),
						).split(',')}
						errorMessage={errors.categories?.message}
						register={register}
						onSelect={value => {
							setValue(
								'categories' as FieldPath<ICreateBookForm>,
								value.join(','),
							)
							setError('categories', {
								message: '',
							})
						}}
					/>
				</FormSection>

				<FormSection label={'Заголовок'}>
					<TextInput
						size={'l'}
						placeholder={'Введите заголовок'}
						error={errors.title?.message}
						errorMessage={errors.title?.message}
						{...register('title')}
					/>
				</FormSection>

				<FormSection label={'Описание'}>
					<TextArea
						size={'l'}
						placeholder={'Введите описание'}
						error={errors.description?.message}
						errorMessage={errors.description?.message}
						{...register('description')}
					/>
				</FormSection>

				<FormSection label={'Автор'}>
					<TextInput
						size={'l'}
						placeholder={'Введите автора'}
						error={errors.author?.message}
						errorMessage={errors.author?.message}
						{...register('author')}
					/>
				</FormSection>

				<FormSection label={'Издатель'}>
					<TextInput
						size={'l'}
						placeholder={'Введите издателя'}
						error={errors.publisher?.message}
						errorMessage={errors.publisher?.message}
						{...register('publisher')}
					/>
				</FormSection>

				<FormSection label={'Правобладатель'}>
					<TextInput
						size={'l'}
						placeholder={'Введите правобладателя'}
						error={errors.holder?.message}
						errorMessage={errors.holder?.message}
						{...register('holder')}
					/>
				</FormSection>

				<FormSection label={'Переводчик'}>
					<TextInput
						size={'l'}
						placeholder={'Введите переводчика'}
						error={errors.translator?.message}
						errorMessage={errors.translator?.message}
						{...register('translator')}
					/>
				</FormSection>

				<Flex gap={5}>
					<FormSection label={'Возрастные ограничения'}>
						<TextInput
							size={'l'}
							type={'number'}
							placeholder={'Введите возрастные ограничения'}
							error={errors.age?.message}
							errorMessage={errors.age?.message}
							{...register('age')}
						/>
					</FormSection>

					<FormSection label={'Бумажных страниц'}>
						<TextInput
							size={'l'}
							type={'number'}
							placeholder={'Введите количество страниц'}
							error={errors.pages?.message}
							errorMessage={errors.pages?.message}
							{...register('pages')}
						/>
					</FormSection>
				</Flex>

				<FormSection label={'Обложка книги'}>
					<FileButton
						name={'image'}
						onChange={file => {
							setValue(
								'image' as FieldPath<ICreateBookForm>,
								file,
							)
							setError('file', {
								message: '',
							})
						}}
						accept={IMAGE_FILE_TYPES}
						errorMessage={errors.image?.message}
						register={register}
					/>
				</FormSection>

				<FormSection label={'Файл книги'}>
					<FileButton
						name={'file'}
						onChange={file => {
							setValue('file' as FieldPath<ICreateBookForm>, file)
							setError('file', {
								message: '',
							})
						}}
						accept={BOOK_FILE_TYPES}
						errorMessage={errors.file?.message}
						register={register}
					/>
				</FormSection>

				<Spacing />
				<Button
					view={'action'}
					size={'l'}
					type={'submit'}
					loading={req.isPending}
				>
					<Icon size={18} data={Plus} />
					Опубликовать
				</Button>

				<QueryProgress
					loading={req.isPending}
					value={uploads.progress}
					total={uploads.total}
					uploaded={uploads.uploaded}
				/>
			</form>
		</FormCard>
	)
}
